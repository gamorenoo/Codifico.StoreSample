import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

// DevExpress
import { DxPopupModule, DxListModule, DxScrollViewModule, DxDataGridModule, DxButtonModule, DxFormModule } from 'devextreme-angular';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './component/forms/home/home.component';
import { OrdersViewComponent } from './component/modals/orders-view/orders-view.component';
import { OrdersNewComponent } from './component/modals/orders-new/orders-new.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    OrdersViewComponent,
    OrdersNewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    DxPopupModule,
    DxListModule,
    DxScrollViewModule,
    DxDataGridModule,
    DxButtonModule,
    DxFormModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
