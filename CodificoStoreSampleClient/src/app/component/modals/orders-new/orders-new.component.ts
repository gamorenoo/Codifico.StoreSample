import { Component, EventEmitter, Input, NgZone, OnInit, Output, ViewChild } from '@angular/core';
import { DxFormComponent, DxTemplateHost, IterableDifferHelper, WatcherHelper } from 'devextreme-angular';
import { NewOrder, OrdersDetail } from 'src/app/models/orders';
import { PredictedOrders } from 'src/app/models/predicted-orders';
import { StoreSampleService } from 'src/app/service/codifico.store.sample.api.service';
import { StylingService } from 'src/app/service/styling.service';
import { v4 as uuid } from 'uuid';

@Component({
  selector: 'app-orders-new',
  templateUrl: './orders-new.component.html',
  styleUrls: ['./orders-new.component.css']
})
export class OrdersNewComponent implements OnInit {
  @Input() showPopup = false;
  @Input() currentPredictedOrders: PredictedOrders = new PredictedOrders();  
  @Output() closePopup = new EventEmitter<boolean>(true);
  @ViewChild('formNewOrder') form!: DxFormComponent;
  empleyees: any = [];
  shippers: any = [];
  products: any = [];
  newOrder: NewOrder = new NewOrder();
  titlePopUp: string = ''; 
  popUpId = uuid();
  formId = uuid();toolbarPopupsCofig = {
    toolbar: 'bottom', location: 'center', widget: 'dxButton', visible: true
  };
  toolbarItemsPopup = [
    {
      ...this.toolbarPopupsCofig,
      options: {
        type: "danger",
        text: 'CLOSE',
        onClick: () => {
          this.showPopup = false;
          this.closePopup.emit(false);
        }
      }
    },
    {
      ...this.toolbarPopupsCofig,
      options: {
        type: "success",
        text: 'SAVE',
        onClick: () => {
          if (!this.form.instance.validate().isValid) {
            return;
          }
          this.saveNewOrder();
          
        }
      }
    }
  ];

  constructor(private storeSampleService: StoreSampleService,
    private stylingService: StylingService) { }

  ngOnInit(): void {
    this.newOrder.ordersDetail = new OrdersDetail();
    this.getEmployees();
    this.getShippers();
    this.getProducts();
    this.titlePopUp = this.currentPredictedOrders.customerName +  ' - New Order'; 
  }

  saveNewOrder() {
    this.newOrder.custid = this.currentPredictedOrders.customerId;
    this.storeSampleService.addOrders(this.newOrder).subscribe( (response: any) => {  
      this.showPopup = false;
      this.closePopup.emit(false);
    }, (err) => {
      console.log(err);
    });
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


  popupHeight = () => {
    return Math.round(window.innerHeight / 1.1);
  }

  popupContentHeight = () => {
    return Math.round(window.innerHeight / 1.5);
  }

  onContentReady(e: any) {
    setTimeout(() => {
      const popUpEl = document.getElementById(this.popUpId);
      if (popUpEl) {
        this.stylingService.setTitleColorStyle(popUpEl, 'green');
        this.stylingService.setTitleTextColorStyle(popUpEl, 'white');
      }
    }, 1);
  }

  

}
