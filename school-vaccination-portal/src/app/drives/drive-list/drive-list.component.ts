import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DriveService } from '../drive.service';
import { VaccinationDrive } from '../../models/vaccination-drive.model';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { RouterModule, Router } from '@angular/router';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';

@Component({
  selector: 'app-drive-list',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    RouterModule,
    MatPaginatorModule,
    
  ],
  templateUrl: './drive-list.component.html',
  styleUrls: ['./drive-list.component.scss']
})
export class DriveListComponent implements OnInit {
  drives: VaccinationDrive[] = [];
  displayedColumns = ['driveName', 'date', 'vaccineName', 'availableDoses', 'applicableClasses', 'actions'];
  dataSourcedrive = new MatTableDataSource<any>([]);
  constructor(private driveService: DriveService, private router: Router) {}
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {
    this.loadDrives();
  }

  loadDrives(): void {
    this.driveService.getDrives().subscribe( data =>{
      this.drives = data
      setTimeout(() => {
        this.dataSourcedrive.paginator = this.paginator;
      }, 10);

    this.dataSourcedrive = new MatTableDataSource(data);

  });
  }

  editDrive(drive: VaccinationDrive): void {
    this.router.navigate(['/drives/edit', drive.id]);
  }

  createDrive(): void {
    this.router.navigate(['/drives/create']);
  }

  formatClassList(classes: string[]): string {
    return classes.join(', ');
  }
}
