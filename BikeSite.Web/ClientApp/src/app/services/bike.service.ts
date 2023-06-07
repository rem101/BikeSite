import {Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Bike} from "../models/Bike.model";
import {catchError, Observable, of, switchMap, throwError} from "rxjs";
import {OperationResult, OperationResultWithValue} from "../models/operation-result";


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

  throwError(error: string): Observable<string> {
    console.log(error);
    return throwError(() => error);
    }
}
