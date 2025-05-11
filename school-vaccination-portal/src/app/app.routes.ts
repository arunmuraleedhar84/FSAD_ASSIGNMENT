import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { StudentFormComponent } from './students/student-form/student-form.component';
import { StudentListComponent } from './students/student-list/student-list.component';
import { DriveListComponent } from './drives/drive-list/drive-list.component';
import { ReportListComponent } from './reports/report-list/report-list.component';
import { authGuard } from './shared/auth.guard';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
    { path: '', redirectTo: 'login', pathMatch: 'full' },
    {
      path: 'dashboard',
      loadComponent: () => import('./dashboard/dashboard/dashboard.component').then(m => m.DashboardComponent),
      canActivate: [authGuard]
      
    },
    {
      path: 'students',
      loadComponent: () => import('./students/student-list/student-list.component').then(m => m.StudentListComponent),
      canActivate: [authGuard]
    },
    { 
      path: 'students/add', 
      component: StudentFormComponent 
    }, 
    { 
      path: 'students/:id/edit', 
      component: StudentFormComponent 
    },

    { 
      path: 'students', 
      component: StudentListComponent 
    },
    { 
      path: 'drives', 
      component: DriveListComponent 
    },
    { 
      path: 'reports', 
      component: ReportListComponent 
    },
    { 
      path: '', 
      redirectTo: 'dashboard', 
      pathMatch: 'full' 
    },
    {
      path: 'students/bulk-upload',
      loadComponent: () =>
      import('./students/student-bulk-upload/student-bulk-upload.component').then(m => m.StudentBulkUploadComponent)
    },
    {
      path: 'drives/create',
      loadComponent: () => import('./drives/drive-form/drive-form.component').then(m => m.DriveFormComponent)
    },
    {
      path: 'drives/edit/:id',
      loadComponent: () => import('./drives/drive-form/drive-form.component').then(m => m.DriveFormComponent)
    }

  ];
