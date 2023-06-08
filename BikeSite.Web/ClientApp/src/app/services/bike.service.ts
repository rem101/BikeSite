import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Bike } from "../models/Bike.model";
import { Observable, of, switchMap, throwError } from "rxjs";
import { OperationResultWithValue} from "../models/operation-result";


@Injectable({
  providedIn: 'root',
})
export class BikeService {
  constructor(private http: HttpClient) {}

  get() {
    return this.http.get<OperationResultWithValue<Bike[]>>('api/bike').pipe(
      switchMap((result: OperationResultWithValue<Bike[]>) => (result.success ? of(result.value) : this.throwError(result.error)))
    );
  }

  create(bike: Bike) {
    return this.http.post<OperationResultWithValue<Bike[]>>('api/bike', bike).pipe(
      switchMap((result: OperationResultWithValue<Bike[]>) => (result.success ? of(result.value) : this.throwError(result.error)))
    );
  }

  update(bike: Bike) {
    return this.http.put<OperationResultWithValue<Bike[]>>('api/bike', bike).pipe(
      switchMap((result: OperationResultWithValue<Bike[]>) => (result.success ? of(result.value) : this.throwError(result.error)))
    );
  }

  delete(bikeId: string) {
    return this.http.delete<OperationResultWithValue<Bike[]>>(`api/bike/${bikeId}`).pipe(
      switchMap((result: OperationResultWithValue<Bike[]>) => (result.success ? of(result.value) : this.throwError(result.error)))
    );
  }

  throwError(error: string): Observable<string> {
    console.log(error);
    return throwError(() => error);
    }
}
