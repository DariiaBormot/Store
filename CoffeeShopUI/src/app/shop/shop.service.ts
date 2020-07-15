import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { from } from 'rxjs';
import { map, delay } from 'rxjs/operators';

import { IPagination } from '../shared/models/pagination';
import { ICategoty } from '../shared/models/categoty';
import { IProductType } from '../shared/models/productType';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:44348/api/';

  constructor(private http: HttpClient) {}

  getProducts(categoryId?: number, productTypeId?: number) {
    let params = new HttpParams();

    if (categoryId) {
      params = params.append('categoryId', categoryId.toString());
    }
    if (productTypeId) {
      params = params.append('typeId', productTypeId.toString());
    }
    return this.http.get<IPagination>(this.baseUrl + 'products', { observe: 'response', params })
    .pipe(
      map(responce => {
          return responce.body;
      })
    );
  }

  getCategories() {
    return this.http.get<ICategoty[]>(this.baseUrl + 'categories');
  }

  getProductTypes() {
    return this.http.get<IProductType[]>(this.baseUrl + 'ProductTypes');
  }
}
