export class Orders {
    public orderid: number = 0;
    public requireddate: Date = new Date();
    public shippeddate: Date = new Date();
    public shipname: string = '';
    public shipaddress: string = '';
    public shipcity: string = '';
}

export class NewOrder {
    public orderid : number = 0;
    public custid: any = null;
    public empid : any = null;
    public shipperid: any = null;
    public shipname:string = '';
    public shipaddress: string = '';
    public shipcity: string = '';
    public orderdate: Date = new Date();
    public requireddate: Date = new Date();
    public shippeddate: Date = new Date();
    public Freight: number = 0;
    public shipcountry: string = '';
    public ordersDetail: OrdersDetail = new OrdersDetail(); 
}

export class OrdersDetail {
    public orderid : number = 0;
    public productid: any = null;
    public unitprice: number = 0;
    public qty: number = 0;
    public discount: number = 0;
}