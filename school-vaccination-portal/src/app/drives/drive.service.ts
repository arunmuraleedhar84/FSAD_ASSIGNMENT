import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VaccinationDrive } from '../models/vaccination-drive.model';

@Injectable({
  providedIn: 'root'
})
export class DriveService {
  private baseUrl = '/api/vaccination-drives';

  constructor(private http: HttpClient) {}

  getDrives(): Observable<VaccinationDrive[]> {
    return this.http.get<VaccinationDrive[]>(this.baseUrl);
  }

  getDriveById(id: number): Observable<VaccinationDrive> {
    return this.http.get<VaccinationDrive>(`${this.baseUrl}/${id}`);
  }

  createDrive(drive: any): Observable<any> {
    return this.http.post('https://localhost:7281/api/VaccinationDrives', drive);
  }

  updateDrive(id: number, drive: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, drive);
  }
}
