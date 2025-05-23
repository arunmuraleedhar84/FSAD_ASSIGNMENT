import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';


export interface DashboardSummary {
  totalStudents: number;
  vaccinatedStudents: number;
  vaccinationPercentage: number;
  upcomingDrivesCount: number;
  nextUpcomingDriveDate: string | null
  
}

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor(private http: HttpClient) { }
  getDashboardSummary() {
    return this.http.get<DashboardSummary>(`${environment.apiUrl}dashboard/summary`);
  }
}
