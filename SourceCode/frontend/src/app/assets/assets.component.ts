import { Component,ChangeDetectionStrategy, OnInit} from '@angular/core';
import {asset} from '../Model/asset'
//import {MatSort} from '../material.module';
//import {Sort} from '@angular/material';
//import {MatSort, MatTableDataSource} from '@angular/material';
 
//import { Assets } from '../mock-assets';
import { AssetService } from '../asset.service';

 
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/delay';
import { APIResult } from '../Model/APIResult';
import { RouterLinkActive, Router } from '@angular/router';

 

@Component({
  selector: 'app-assets',
  templateUrl: './assets.component.html', 
  styleUrls: ['./assets.component.css'],
  //changeDetection: ChangeDetectionStrategy.OnPush
})
export class AssetsComponent implements OnInit {
  assets: asset[];
  asyncAssets: Observable<asset[]>;
  loading: boolean;

  //for future  to do class for pagination
  sidx:string;
  sord:string;
  page:number;
  pageSize:number
  totalPages : number;
  totalRecords : number;
  selectedAsset: asset;
  displayedColumns = ['FileName','MimeType', 'CreatedBy'];
  constructor(private assetService: AssetService,private _router:Router) {
    
   }
   
   ngOnInit() {
    this.sidx = 'FileName';
    this.sord='asc';
    this.page=1;
    this.pageSize=10;
    //this.getAssets();
    this.getPage(1);
  }
  getPage(page: number) {
    this.loading = true;
    //this.getAssets();
    this.asyncAssets = //serverCall(this.assets, page)
    this.assetService.getAssets(this.sidx,this.sord,this.page,this.pageSize)
        .do(res => {
            this.totalPages = res.TotalPages;
            //alert(this.totalPages);
            this.page = page;
            this.totalRecords = res.TotalRecords
            this.loading = false;
            
        })
        .map(res => res.data);
}

getAssets(): void {
      //this.assets.push(asset);
      // this.assetService.getAssets().subscribe(ast=>this.assets=ast);
      this.assetService.getAssets(this.sidx,this.sord,this.page,this.pageSize)
      .subscribe(ast=>this.assets=ast.data);
    //alert(x);
}
  onSelect(asset: asset): void {
    this.selectedAsset = asset;
  } 
  
  showFor(asset: asset, mode:string) {
    this.assetService.selectedAsset = Object.assign({}, asset);
    this._router.navigate( [ {id: asset.Id, mode: mode}]);
  }
  delete(asset: asset): void {
    //this.assets = this.assets.filter(h => h !== asset);
    this.assetService.deleteAsset( asset.Id).subscribe();
  }
}

