import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { DashboardService, DashboardSummary } from '../dashboard.service';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatListModule } from '@angular/material/list';  // For mat-nav-list
import { MatSidenavModule } from '@angular/material/sidenav';  // If you're using a sidenav
import { MatIconModule } from '@angular/material/icon';  // For icons in the menu
import { MatButtonModule } from '@angular/material/button';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [RouterModule,CommonModule, MatCardModule,MatProgressBarModule,MatListModule,
    MatSidenavModule, MatIconModule,MatButtonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})

export class DashboardComponent  {
  summary!: DashboardSummary;

  constructor(private dashboardService: DashboardService,private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.dashboardService.getDashboardSummary().subscribe({
      next: (data) => this.summary = data,
      error: (err) => console.error('Failed to load dashboard data', err)
    });
  }

  logout() {
    this.authService.clearToken();  
    this.router.navigate(['/login']);  
  }
}

