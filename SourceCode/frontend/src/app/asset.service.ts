import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';

import { asset } from './Model/asset';
import { APIResult } from './Model/APIResult';

import { MessageService } from './message.service';

import { HttpClientModule }    from '@angular/common/http';

import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
//import { Message } from '@angular/compiler/src/i18n/i18n_ast';


 
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json'
        })
};

@Injectable()
export class AssetService {

  private assetsUrl = 'http://localhost:6267/api/Asset/';  // URL to web api
  assets : asset[];
  selectedAsset : asset;
  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

    getAssets2(){
      return this.http.get(this.assetsUrl+'GetAssets')
      .map((res:Response) => res.json());
  }


  

  getAssets (sidx:string,sord:string,page:number,pageSize:number): Observable<APIResult> {
   
    var url = this.assetsUrl+'GetAssets?';
    url+="sidx=" + sidx;
    url+="&sord=" + sord;
    url+="&page=" + page;
    url+="&pageSize=" + pageSize;
    return this.http.get<APIResult>(url)
      .pipe(
        
        map(r => r),
        tap(r => this.log(`fetched assets`)),
        catchError(this.handleError('getAssets', null))
      );
  }
  // getAssets (sidx:string,sord:string,page:number,pageSize:number): Observable<asset[]> {
  //   var url = this.assetsUrl+'GetAssets?';
  //   url+="sidx=" + sidx;
  //   url+="&sord=" + sord;
  //   url+="&page=" + page;
  //   url+="&pageSize=" + pageSize;
  //   return this.http.get<APIResult>(url)
  //     .pipe(
  //       map(r => r.data),
  //       tap(r => this.log(`fetched assets`)),
  //       catchError(this.handleError('getAssets', []))
  //     );
  // }
 
  
  // getAssets (): Observable<asset[]> {
  //   return this.http.get<asset[]>(this.assetsUrl+'GetAssets')
  //     .pipe(
  //       tap(assets => this.log(`fetched assets`)),
  //       catchError(this.handleError('getAssets3', []))
  //     );
  // }

  /** GET Asset from the server */
  // getAssets (): Observable<asset[]> {
    
  //   return this.http.get<asset[]>(this.assetsUrl+'GetAssets')
  //     .pipe(
  //       tap(assets => this.log(`fetched assets`)),
  //       catchError(this.handleError('getAssets', []))
  //     );
  // }

  /** GET asset by id. Return `undefined` when id not found */
  getAssetNo404<Data>(id: number): Observable<asset> {
    const url = `${this.assetsUrl}/?id=${id}`;
    return this.http.get<asset[]>(url)
      .pipe(
        map(assets => assets[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? `fetched` : `did not find`;
          this.log(`${outcome} asset id=${id}`);
        }),
        catchError(this.handleError<asset>(`getAsset id=${id}`))
      );
  }

  /** GET asset by id. Will 404 if id not found */
  getAsset(assetid: string): Observable<asset> {
    const url = `${this.assetsUrl+'GetAssetById?assetid='}${assetid}`;
    return this.http.get<asset>(url).pipe(
      tap(_ => this.log(`fetched asset id=${assetid}`)),
      catchError(this.handleError<asset>(`getAsset id=${assetid}`))
    );
  }

  /* GET assets whose name contains search term */
  searchAssets(term: string): Observable<asset[]> {
    if (!term.trim()) {
      // if not search term, return empty asset array.
      return of([]);
    }
    return this.http.get<asset[]>(`api/assets/?name=${term}`).pipe(
      tap(_ => this.log(`found assets matching "${term}"`)),
      catchError(this.handleError<asset[]>('searchAssets', []))
    );
  }

  //////// Save methods //////////

  /** POST: add a new asset to the server */
  addAsset (asset: asset): Observable<asset> {
    return this.http.post<asset>(this.assetsUrl, asset, httpOptions).pipe(
      tap((asset: asset) => this.log(`added asset w/ id=${asset.Id}`)),
      catchError(this.handleError<asset>('addAsset'))
    );
  }

  /** DELETE: delete the asset from the server */
  deleteAsset (id: string): Observable<asset> {
   
    const url = `${this.assetsUrl+'DeleteAsset?id='}${id}`;

    return this.http.delete<asset>(url, httpOptions).pipe(
      tap(_ => this.log(`deleted asset id=${id}`)),
      catchError(this.handleError<asset>('deleteAsset'))
    );
  }

  /** PUT: update the asset on the server */
  updateAsset (asset: asset): Observable<any> {
    const id = typeof asset === 'number' ? asset : asset.Id;
    const url = `${this.assetsUrl+'PutAsset?id='}${id}`;
    return this.http.put(url, asset, httpOptions).pipe(
      tap(_ => this.log(`updated asset id=${asset.Id}`)),
      catchError(this.handleError<any>('updateAsset'))
    );
    // return this.http.put(this.assetsUrl+'/PutAsset?id=${asset.AssetId}', asset, httpOptions).pipe(
    //   tap(_ => this.log(`updated asset id=${asset.AssetId}`)),
    //   catchError(this.handleError<any>('updateAsset'))
    // );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a AssetService message with the MessageService */
  private log(message: string) {
    this.messageService.add('AssetService: ' + message);
  }
}