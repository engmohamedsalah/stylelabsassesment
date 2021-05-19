import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { asset }         from '../Model/asset';
import { AssetService }  from '../asset.service';

@Component({
  selector: 'app-asset-detail',
  templateUrl: './asset-detail.component.html',
  styleUrls: [ './asset-detail.component.css' ]
})
export class AssetDetailComponent implements OnInit {
  @Input() selectedAsset: asset;
  IsEdit:boolean;
  constructor(
    private route: ActivatedRoute,
    private assetService: AssetService,
    private location: Location,
    
  ) 
  {
   
  }

  ngOnInit(): void {
    //this.selectedAsset = this.route.snapshot.paramMap.get('asset');
    var mode = this.route.snapshot.paramMap.get('mode');
    this.IsEdit= (mode=='edit');
    this.getAsset();
    
  }

  getAsset(): void {
     const assetid = this.route.snapshot.paramMap.get('Id');
     this.assetService.getAsset(assetid).subscribe(ast=>this.selectedAsset=ast);
    //   .subscribe(asset => this.asset = asset);
  }

  goBack(): void {
    this.location.back();
  }
  save()
  {
    this.assetService.updateAsset(this.selectedAsset)
    .subscribe(() => this.goBack());
  }
}
