import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StoreSampleService {
  urlBase: string = 'https://localhost:44391/api'
  constructor(
    private http: HttpClient
  ) { }

  public getEmployees() {
    return this.http.get<any>(`${this.urlBase}/Employees`);
  }

  public getProducts() {
    return this.http.get<any>(`${this.urlBase}/Products`);
  }

  public getShippers() {
    return this.http.get<any>(`${this.urlBase}/Shippers`);
  }

  public getPredictedOrders() {
    return this.http.get<any>(`${this.urlBase}/Orders/predictedOrders`);
  }

  public getOrdersByCustomer(custmerId: number) {
    return this.http.get<any>(`${this.urlBase}/Orders/customers/${custmerId}`);
  }

  public addOrders(newOrders: any) {
    return this.http.post<any>(`${this.urlBase}/Orders`, newOrders);
  }

}
