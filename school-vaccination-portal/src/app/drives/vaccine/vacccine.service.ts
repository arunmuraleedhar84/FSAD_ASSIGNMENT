import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';


export interface Vaccine {
  id: number;
  name: string;
  manufacturer: string;
  // Add other properties your API returns
}
@Injectable({
  providedIn: 'root'
})
export class VaccineService {

  constructor(private http: HttpClient) {}

  getVaccines() {
    return this.http.get(`${environment.apiUrl}Vaccines`);
  }
}
