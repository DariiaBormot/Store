import { Component, OnInit, ɵALLOW_MULTIPLE_PLATFORMS, ViewChild, ElementRef } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';
import { ICategoty } from '../shared/models/categoty';
import { IProductType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: true}) searchTern: ElementRef;
  products: IProduct[];
  categories: ICategoty[];
  productTypes: IProductType[];
  shopParams = new ShopParams();
  totalCount: number;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: low to high', value: 'priceAsc' },
    { name: 'Price: high to low', value: 'priceDesc' },
  ];

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getProducts();
    this.getCategories();
    this.getProductTypes();
  }

  getProducts(): void {
    this.shopService
      .getProducts(this.shopParams)
      .subscribe(
        (responce) => {
          this.products = responce.data;
          this.shopParams.pageNumber = responce.pageIndex;
          this.shopParams.pageSize = responce.pageSize;
          this.totalCount = responce.count;
        },
        (error) => {
          console.log(error);
        }
      );
  }

  getCategories(): void {
    this.shopService.getCategories().subscribe(
      (responce) => {
        this.categories = [{ id: 0, name: 'All' }, ...responce];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getProductTypes(): void {
    this.shopService.getProductTypes().subscribe(
      (responce) => {
        this.productTypes = [{ id: 0, name: 'All' }, ...responce];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  onCategorySelected(categoryId: number): void {
    this.shopParams.categoryId = categoryId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onProductTypeSelected(productTypeId: number): void {
    this.shopParams.productTypeId = productTypeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort: string): void {
    this.shopParams.sort = sort;
    this.getProducts();
  }

  onPageChanged(event: any): void{
    if (this.shopParams.pageNumber !== event){
    this.shopParams.pageNumber = event;
    this.getProducts();
    }
  }

  onSearch(): void{
      this.shopParams.search = this.searchTern.nativeElement.value;
      this.shopParams.pageNumber = 1;
      this.getProducts();
  }

  onReset(): void{
    this.searchTern.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }
}
