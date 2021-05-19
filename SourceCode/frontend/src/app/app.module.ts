import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';
import { HttpClientModule }    from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HttpModule } from '@angular/http'

import {NgxPaginationModule} from 'ngx-pagination'; // <-- import the module


import { AppComponent }         from './app.component';
import { HomeComponent }   from './home/home.component';
import { DashboardComponent }   from './dashboard/dashboard.component';
import { AssetDetailComponent }  from './asset-detail/asset-detail.component';
import { AssetsComponent }      from './assets/assets.component';
import { AssetService }          from './asset.service';
import { MessageService }       from './message.service';
import { MessagesComponent }    from './messages/messages.component';

import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService }  from './in-memory-data.service';

import {MaterialModule} from './material.module';
//import {FlexLayoutModule} from '@angular/flex-layout';


import { AppRoutingModule }     from './app-routing.module';
import { AssetSearchComponent } from './asset-search/asset-search.component';

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    HttpModule,
    MaterialModule, 
    NgxPaginationModule, 
  //  FlexLayoutModule,
    //HttpClientInMemoryWebApiModule,
     // The HttpClientInMemoryWebApiModule module intercepts HTTP requests
    // and returns simulated server responses.
    // Remove it when a real server is ready to receive requests.
    // HttpClientInMemoryWebApiModule.forRoot(
    //   InMemoryDataService, { dataEncapsulation: false }
    // )

  ],
  declarations: [
    AppComponent,
    HomeComponent,
    DashboardComponent,
    AssetsComponent,
    AssetDetailComponent,
    MessagesComponent,
    AssetSearchComponent
  ],
  providers: [ AssetService, MessageService ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
