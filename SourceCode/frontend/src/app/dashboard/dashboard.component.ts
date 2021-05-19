import { Component, OnInit } from '@angular/core';
import { asset } from '../Model/asset';
import { AssetService } from '../asset.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  assets: asset[] = [];
  constructor(private assetService:AssetService) { }

  ngOnInit() {
    //this.getAssets();
  }
  // getAssets(): void {
  //   this.assetService.getAssets()
  //     .subscribe(ast => this.assets = ast.slice(1, 5));
  // }

}
