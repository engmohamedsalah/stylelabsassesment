import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent }   from './dashboard/dashboard.component';
import { AssetsComponent }      from './assets/assets.component';
import { AssetDetailComponent }  from './asset-detail/asset-detail.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  //{ path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  
  { path: 'dashboard', component: DashboardComponent },
  { path: 'assetDetail/:Id/:mode', component: AssetDetailComponent },
  { path: 'assets', component: AssetsComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
