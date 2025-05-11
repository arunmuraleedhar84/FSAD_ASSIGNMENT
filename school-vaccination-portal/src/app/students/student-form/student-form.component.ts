import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators,ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from '../../students/student.service';
import { Student } from '../../models/student.model';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox'; 
import { MatDialogModule, MatDialog } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { inject } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatPaginatorModule } from '@angular/material/paginator';

@Component({
  selector: 'app-student-form',
  standalone: true,
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.scss'],
  imports: [
    MatDialogModule,
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    MatButtonModule,
    MatCardModule,
    MatPaginatorModule
  ],
})
export class StudentFormComponent {
  studentForm: FormGroup;
  studentId: number | null = null;
  isEditMode = false;
  private studentService = inject(StudentService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);

  constructor(private fb: FormBuilder) {
    this.studentForm = this.fb.group({
      fullName: ['', Validators.required],
      className: ['', Validators.required],
      section: ['', Validators.required],
      guardianName: ['', Validators.required]
    });

    const id = this.route.snapshot.paramMap.get('id');
    console.log("Student Id : " + id)
    if (id) {
      this.studentId = +id;
      this.isEditMode = true;
      this.loadStudent(this.studentId);
    }
  }

  loadStudent(id: number): void {
    this.studentService.getStudentById(id).subscribe(student => {
      this.studentForm.patchValue(student);
    });
  }

  onSubmit(): void {
    if (this.studentForm.invalid) return;

    const studentData: Student = this.studentForm.value;

    if (this.isEditMode && this.studentId) {
      //console.log(studentData)
      this.studentService.update(this.studentId, studentData).subscribe(() => {
        this.router.navigate(['/students']);
      });
    } else {
      this.studentService.create(studentData).subscribe(() => {
        this.router.navigate(['/students']);
      });
    }
  }

  cancel(): void {
    this.router.navigate(['/students']);
  }
}
