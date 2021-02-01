import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
busyRequestCout = 0;

  constructor(private spinnerService: NgxSpinnerService) { }

  busy(): void{
    this.busyRequestCout++;
    this.spinnerService.show(undefined, {
      type: 'ball-atom',
      bdColor: 'rgba(255, 255, 255, 0.7)',
      color: '#333333'
    });
  }

  idle(): void{
this.busyRequestCout--;
if (this.busyRequestCout <= 0){
  this.busyRequestCout = 0;
  this.spinnerService.hide();
}
  }
}
