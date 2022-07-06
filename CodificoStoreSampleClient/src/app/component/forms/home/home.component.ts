import { Component, OnInit } from '@angular/core';
import { PredictedOrders } from 'src/app/models/predicted-orders';
import { StoreSampleService } from 'src/app/service/codifico.store.sample.api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  listPredictedOrders: PredictedOrders[] = [];
  showPopupOrdersView: boolean = false;
  showPopupOrdersNew: boolean = false;
  currentPredictedOrders: PredictedOrders = new PredictedOrders();
  constructor(private storeSampleService: StoreSampleService) { }

  ngOnInit(): void {
    this.getPredictedOrders();
  }

  getPredictedOrders() {
    this.storeSampleService.getPredictedOrders().subscribe( (response: any) => {
      this.listPredictedOrders = response;
    }, (err) => {
      console.log(err);
    });
  }

  viewOrders(e: any, row: any){
    this.currentPredictedOrders = row.data as PredictedOrders;
    this.showPopupOrdersView=true;
  }

  closePopupOrdersView(){
    this.showPopupOrdersView = false;
  }

  closePopupOrdersNew(){
    this.showPopupOrdersNew = false;
    this.getPredictedOrders();
  }

  newOrders(e: any, row: any){
    this.currentPredictedOrders = row.data as PredictedOrders;
    this.showPopupOrdersNew = true;
  }

  popupContentHeight = () => {
    return Math.round(window.innerHeight / 1.1);
  }

}
