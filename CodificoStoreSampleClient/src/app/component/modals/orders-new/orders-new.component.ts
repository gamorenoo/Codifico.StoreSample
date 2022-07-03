import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NewOrder, OrdersDetail } from 'src/app/models/orders';
import { PredictedOrders } from 'src/app/models/predicted-orders';
import { StoreSampleService } from 'src/app/service/codifico.store.sample.api.service';

@Component({
  selector: 'app-orders-new',
  templateUrl: './orders-new.component.html',
  styleUrls: ['./orders-new.component.css']
})
export class OrdersNewComponent implements OnInit {
  @Input() showPopup = false;
  @Input() currentPredictedOrders: PredictedOrders = new PredictedOrders();  
  @Output() closePopup = new EventEmitter<boolean>(true);
  empleyees: any = [];
  shippers: any = [];
  products: any = [];
  newOrder: NewOrder = new NewOrder();
  constructor(private storeSampleService: StoreSampleService) { }

  ngOnInit(): void {
    this.newOrder.ordersDetail = new OrdersDetail();
    this.getEmployees();
    this.getShippers();
    this.getProducts();
  }

  getEmployees() {
    this.storeSampleService.getEmployees().subscribe( (response: any) => {
      this.empleyees = response;
    }, (err) => {
      console.log(err);
    });
  }

  getShippers() {
    this.storeSampleService.getShippers().subscribe( (response: any) => {
      this.shippers = response;
    }, (err) => {
      console.log(err);
    });
  }

  getProducts() {
    this.storeSampleService.getProducts().subscribe( (response: any) => {
      this.products = response;
    }, (err) => {
      console.log(err);
    });
  }



}
