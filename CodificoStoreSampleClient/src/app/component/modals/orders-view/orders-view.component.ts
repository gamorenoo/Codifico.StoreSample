import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Orders } from 'src/app/models/orders';
import { PredictedOrders } from 'src/app/models/predicted-orders';
import { StoreSampleService } from 'src/app/service/codifico.store.sample.api.service';
import { v4 as uuid } from 'uuid';

@Component({
  selector: 'app-orders-view',
  templateUrl: './orders-view.component.html',
  styleUrls: ['./orders-view.component.css']
})
export class OrdersViewComponent implements OnInit {
  popUpId = uuid();
  formId = uuid();
  @Input() showPopup = false;
  @Input() currentPredictedOrders: PredictedOrders = new PredictedOrders();
  @Output() closePopup = new EventEmitter<boolean>(true);
  listOrders: Orders[] = []; 
  toolbarPopupsCofig = {
    toolbar: 'bottom', location: 'center', widget: 'dxButton', visible: true
  };
  toolbarItemsPopup = [
    {
      ...this.toolbarPopupsCofig,
      options: {
        // elementAttr: { style: 'color: red' },
        type: "danger",
        text: 'CLOSE',
        onClick: () => {
          this.showPopup = false;
          this.closePopup.emit(false);
        }
      }
    }
  ];
  
  titlePopUp: string = '';

  constructor(private storeSampleService: StoreSampleService) { }

  ngOnInit(): void {
    this.getOrdersCustomer();
    this.titlePopUp = this.currentPredictedOrders.customerName +  ' - Orders';
  }

  getOrdersCustomer() {
    this.storeSampleService.getOrdersByCustomer(this.currentPredictedOrders.customerId).subscribe( (response: any) => {
      this.listOrders = response;
    }, (err) => {
      console.log(err);
    });
  }

  popupHeight = () => {
    return Math.round(window.innerHeight / 1.1);
  }

  popupContentHeight = () => {
    return Math.round(window.innerHeight / 1.3);
  }

}
