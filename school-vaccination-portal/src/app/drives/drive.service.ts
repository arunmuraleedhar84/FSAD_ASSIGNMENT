import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { VaccinationDrive } from '../models/vaccination-drive.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DriveService {
public baseUrl  = environment.apiUrl
  constructor(private http: HttpClient) {}

  getDrives(): Observable<VaccinationDrive[]> {
    return this.http.get<VaccinationDrive[]>(this.baseUrl +'VaccinationDrives');
  }

  getDriveById(id: number): Observable<VaccinationDrive> {
    return this.http.get<VaccinationDrive>(this.baseUrl +`VaccinationDrives/${id}`);
  }

  createDrive(drive: any): Observable<any> {
    return this.http.post(this.baseUrl +'VaccinationDrives', drive);
  }

  updateDrive(id: number, drive: any): Observable<any> {
    return this.http.put(this.baseUrl +`VaccinationDrives/${id}`, drive);
  }
}
