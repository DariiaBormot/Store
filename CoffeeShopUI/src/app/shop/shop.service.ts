import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { from } from 'rxjs';
import { map, delay } from 'rxjs/operators';

import { IPagination } from '../shared/models/pagination';
import { ICategoty } from '../shared/models/categoty';
import { IProductType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:44348/api/';

  constructor(private http: HttpClient) {}

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.categoryId !== 0) {
      params = params.append('categoryId', shopParams.categoryId.toString());
    }
    if (shopParams.productTypeId !== 0 ) {
      params = params.append('typeId', shopParams.productTypeId.toString());
    }
    if(shopParams.search){
      params = params.append('search', shopParams.search)
    }

    params = params.append('sort', shopParams.sort.toString());
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

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
