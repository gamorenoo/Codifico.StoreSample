export class PredictedOrders{
    public customerId: number = 0;
    customerName: string = '';
    lastOrderDate: Date = new Date();
    nextPredicatedOrder: Date = new Date();
}