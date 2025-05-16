import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { StudentService } from '../../students/student.service';
import { Student } from '../../models/student.model';
import { inject } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';  
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { CommonModule } from '@angular/common';
import { MatChipsModule } from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';


@Component({
  selector: 'app-student-list',
  standalone: true,
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.scss'],
  imports: [
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatPaginatorModule,
    CommonModule,
    MatChipsModule,
    MatFormFieldModule,
    
  ],
})
export class StudentListComponent {
  dataSourcestudent = new MatTableDataSource<any>([]);
  
   displayedColumns: string[] = ['fullName', 'className', 'isVaccinated', 'actions'];
  private studentService = inject(StudentService);
  public router = inject(Router);
  constructor() {
  }
  @ViewChild(MatPaginator) paginator!: MatPaginator;

 

  ngOnInit(): void {
    this.loadStudents();
  }

  
ngAfterViewInit() {
    this.dataSourcestudent.paginator = this.paginator;
  }
  
  loadStudents(): void {
    this.studentService.getAll().subscribe(students => {
      setTimeout(() => {
        this.dataSourcestudent.paginator = this.paginator;
      }, 10);

    this.dataSourcestudent = new MatTableDataSource(students);


    });
  }

  onEdit(studentId: number): void {
    this.router.navigate(['/students', studentId, 'edit']);
  }

  onDelete(studentId: number): void {
    if (confirm('Are you sure you want to delete this student?')) {
    this.studentService.delete(studentId).subscribe(() => {
      this.loadStudents();
    });
    }
  }



}
