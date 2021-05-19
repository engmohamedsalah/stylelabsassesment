using Microsoft.Ajax.Utilities;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebExperience.DAL;
using WebExperience.Service;
using WebExperience.Test.Models;

namespace WebExperience.Test.Controllers
{

   // [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AssetController : ApiController
    {
        // TODO
        // Create an API controller via REST to perform all CRUD operations on the asset objects created as part of the CSV processing test
        // Visualize the assets in a paged overview showing the title and created on field
        // Clicking an asset should navigate the user to a detail page showing all properties
        // Any data repository is permitted
        // Use a client MVVM framework
        // GET api/Employee
        //initialize service object
        IAssetService _AssetService;
        
        public AssetController(IAssetService AssetService)
        {
            _AssetService = AssetService;
        }
        /// <summary>
        /// get all assets that match the param
        /// </summary>
        /// <param name="sidx">sorting param</param>
        /// <param name="sord">asc / desc </param>
        /// <param name="page">page number start from 1</param>
        /// <param name="pageSize">page size = number of record per page</param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpGet]
        //[Route("api/Asset/GetAssets")]
        public IHttpActionResult GetAssets(string sidx, string sord, int page, int pageSize)
        {
            try
            {
                //get data from the repository
                var result = _AssetService.GellAllQueryWithSort(sidx, sord);

                //index start from 0
                int pageIndex = page - 1;


                //get total of the records
                int totalRecords = _AssetService.Count();
                //calculate the number of pages
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
                //return the result
                var jsonData = new APIResult()
                {
                    TotalPages = totalPages,
                    Page = page,
                    TotalRecords = totalRecords,
                    data = result.Skip(pageIndex * pageSize).Take(pageSize)
                };

                return Json(jsonData);
            }
            catch (Exception ex)
            {
                return SendErrorMessage(ex.Message, HttpStatusCode.BadRequest);
            }


        }
        /// <summary>
        /// get asset by id and return the data
        /// </summary>
        /// <param name="assetid"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpGet]
        //[Route("api/Asset/GetAssetById")]
        public IHttpActionResult GetAssetById(string assetid)
        {
            try
            {
                Guid id = Guid.Parse(assetid);
                return Json(_AssetService.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

        /// <summary>
        /// add new asset object
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpPost]
        public IHttpActionResult PostAsset([FromBody] Asset asset)
        {
            try
            {
                var existAsset = _AssetService.GetById(asset.Id);
                if (existAsset != null)
                    return SendErrorMessage("Asset already exist", HttpStatusCode.Found);
                

                return Ok(_AssetService.Create(asset));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
       /// <summary>
        /// delete asset object by asset id
        /// </summary>
        /// <param name="id">asset id</param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpDelete]
        //[Route("api/Asset/DeleteAsset/assetid")]
        public IHttpActionResult DeleteAsset(string id)
        {

            try
            {
                Guid assetid = Guid.Parse(id);
                var asset = _AssetService.GetById(assetid);
                if (asset == null)
                {
                    return NotFound();
                }

                _AssetService.Delete(asset);

                return Ok(asset);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// update the asset operation
        /// take id for validation
        /// and the updated object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="asset"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpPut]
        public IHttpActionResult PutAsset(string id, [FromBody]Asset asset)
        {
            //validation check 
            if (Guid.Parse(id) != asset.Id)
                return BadRequest();
            try
            {
                _AssetService.Update(asset);
                return Ok("Successfully");
            }

            catch (DbUpdateConcurrencyException ex)
            {
                if (_AssetService.GetById(asset.Id) == null)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
        }


        /// <summary>
        /// send error message for response
        /// </summary>
        /// <param name="message">Required. </param>
        /// <param name="statusCode">Optional. The default value is HttpStatusCode.NotFound.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public IHttpActionResult SendErrorMessage(string message, HttpStatusCode statusCode = HttpStatusCode.NotFound)
        {
            HttpError err = new HttpError(message);
            return ResponseMessage(Request.CreateResponse(statusCode, message));

        }

    }
}
