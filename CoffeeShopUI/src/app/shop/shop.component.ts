import { Component, OnInit, ɵALLOW_MULTIPLE_PLATFORMS } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';
import { ICategoty } from '../shared/models/categoty';
import { IProductType } from '../shared/models/productType';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  products: IProduct[];
  categories: ICategoty[];
  productTypes: IProductType[];
  categoryIdselected = 0;
  productTypeIdselected = 0;

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getProducts();
    this.getCategories();
    this.getProductTypes();
  }

  getProducts(): void {
    this.shopService.getProducts(this.categoryIdselected, this.productTypeIdselected).subscribe(
      (responce) => {
        this.products = responce.data;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getCategories(): void {
    this.shopService.getCategories().subscribe((responce) => {
      this.categories = [{id: 0, name: 'All'}, ...responce];
    }, (error) => {
      console.log(error);
    });
  }

  getProductTypes(): void {
    this.shopService.getProductTypes().subscribe((responce) => {
      this.productTypes =  [{id: 0, name: 'All'}, ...responce];
    }, (error) => {
      console.log(error);
    });
  }

  onCategorySelected(categoryId: number): void{
    this.categoryIdselected = categoryId;
    this.getProducts();
  }

  onProductTypeSelected(productTypeId: number): void{
    this.productTypeIdselected = productTypeId;
    this.getProducts();
  }

}
