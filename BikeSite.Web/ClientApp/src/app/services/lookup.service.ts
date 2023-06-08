import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Bike, BikeBrand} from "../models/Bike.model";
import { Observable, of, switchMap, throwError } from "rxjs";
import { OperationResultWithValue} from "../models/operation-result";


@Injectable({
  providedIn: 'root',
})

export class LookupService {
  constructor(private http: HttpClient) {}

  getBrands() {
    return this.http.get<OperationResultWithValue<BikeBrand[]>>('api/lookup/bike-brands').pipe(
      switchMap((result: OperationResultWithValue<BikeBrand[]>) => (result.success ? of(result.value) : this.throwError(result.error)))
    );
  }

  throwError(error: string): Observable<string> {
    console.log(error);
    return throwError(() => error);
  }
}
