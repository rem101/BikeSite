import {Component, OnInit} from '@angular/core';
import {BikeService} from "../services/bike.service";
import {Bike} from "../models/Bike.model";
import {catchError, forkJoin, Observable, throwError} from "rxjs";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  bikes: Bike[] = [];

  constructor(private bikeService: BikeService) {}

  ngOnInit() {
    forkJoin([
      this.bikeService.get().pipe(catchError((err) => this.handleError(err)))
      ]
    )
      .subscribe(([bikes]) => {
        console.log(bikes);
        this.bikes = bikes;
      });
  }

  private handleError(error: string): Observable<any> {
    console.log(error);

    return throwError(error);
  }
}
