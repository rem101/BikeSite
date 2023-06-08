import {Component, OnInit, ViewChild} from '@angular/core';
import { BikeService } from "../services/bike.service";
import { Bike, BikeBrand } from "../models/Bike.model";
import { catchError, forkJoin, Observable, throwError } from "rxjs";
import { LookupService } from "../services/lookup.service";
import { MessageService } from 'primeng/api';
import {Table} from "primeng/table";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [MessageService]
})
export class HomeComponent implements OnInit{

  @ViewChild('dt') table: any;
  bikes: Bike[] = [];
  bikesCopy: { [bikeId: string]: Bike } = {};
  brands: BikeBrand[] = [];

  constructor(private bikeService: BikeService,
              private lookupService: LookupService,
              private messageService: MessageService) {}

  ngOnInit() {
    forkJoin([
      this.bikeService.get().pipe(catchError((err) => this.handleError(err))),
      this.lookupService.getBrands().pipe(catchError((err) => this.handleError(err))),
      ]
    )
      .subscribe(([bikes, brands]) => {
        this.bikes = bikes;
        this.brands = brands;
      });
  }

  onRowEditInit(bike: Bike) {
    if (!!bike.bikeId)
      this.bikesCopy[bike.bikeId] = { ...bike };
  }

  onRowEditSave(bike: Bike) {
    if (!bike.model || bike.model.trim() === '') {
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Model is required.' });
      return;
    }
    if (!bike.frameSize || bike.frameSize.toString().trim() === '' || bike.frameSize === 0) {
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Frame size is required.' });
      return;
    }
    if (!bike.price || bike.price.toString().trim() === '') {
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Price is required.' });
      return;
    }
    this.bikeService.update(bike).pipe(catchError((err) => this.handleError(err)))
      .subscribe((bikes) => {
        this.bikes = bikes;
        this.messageService.add({severity: 'success', summary: 'Success', detail: 'Bike was edited.'});
      });
  }

  onRowEditCancel(bike: Bike, index: number) {
    if (!!bike.bikeId)
    {
      this.bikes[index] = this.bikesCopy[bike.bikeId];
      delete this.bikesCopy[bike.bikeId];
      this.messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Edit was cancelled.' });
    } else {
      this.bikes.pop();
      this.messageService.add({ severity: 'warn', summary: 'Warning', detail: 'Create was cancelled.' });
    }

  }

  onRowDelete(bike: Bike) {
    if (!!bike.bikeId)
      this.bikeService.delete(bike.bikeId).pipe(catchError((err) => this.handleError(err)))
        .subscribe((bikes) => {
          this.bikes = bikes;
          this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Bike was deleted.' });
        });
  }

  onNewRow() {
    const newRow = {...{bikeId: undefined, model: '', price: 0, frameSize: 12, brand: this.brands[0]}};
    this.bikes = [...this.bikes, newRow];
    this.table.initRowEdit(newRow);
  }

  private handleError(error: string): Observable<any> {
    this.messageService.add({ severity: 'error', summary: 'Error', detail: error });
    return throwError(() => error);
  }
}
