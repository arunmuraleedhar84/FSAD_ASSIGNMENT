import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray,ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DriveService } from '../drive.service';
import { VaccinationDrive } from '../../models/vaccination-drive.model';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon'; 
import { Vaccine } from '../vaccine/vaccine.model';
import { VaccineService } from '../vaccine/vacccine.service';



@Component({
  selector: 'app-drive-form',
  standalone: true,
  imports: [
            CommonModule,
            ReactiveFormsModule,
            MatFormFieldModule,
            MatInputModule,
            MatButtonModule,
            MatIconModule,
            MatSelectModule,MatCardModule
          ],

  templateUrl: './drive-form.component.html',
  styleUrls: ['./drive-form.component.scss']
})
export class DriveFormComponent implements OnInit {
  driveForm!: FormGroup;
  driveId?: number;
  vaccines: any;
  allClasses = ['Class 1', 'Class 2', 'Class 3', 'Class 4'];

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private driveService: DriveService,
    private vaccineService: VaccineService
  ) {}

  ngOnInit(): void {
    this.driveForm = this.fb.group({
      driveName: ['', Validators.required],
      date: ['', [Validators.required, this.futureDateValidator(15)]],
      vaccineId: [null, Validators.required],
      availableDoses: [[Validators.required, Validators.min(1)]],
      applicableClasses: [''],
    });

    this.loadVaccines();

    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.driveId = +id;
      this.loadDrive(this.driveId);
    }
  }

  get applicableClasses(): FormArray {
    return this.driveForm.get('applicableClasses') as FormArray;
  }

  onClassToggle(className: string, checked: boolean): void {
    const classes = this.applicableClasses;
    const index = classes.value.indexOf(className);
    if (checked && index === -1) {
      classes.push(this.fb.control(className));
    } else if (!checked && index !== -1) {
      classes.removeAt(index);
    }
  }

  loadVaccines(): void {
    this.vaccineService.getVaccines().subscribe({
      next: (data) => {this.vaccines = data;},
      error: (err) => {
        console.error('Error loading vaccines:', err);
      }
    });
  }

  loadDrive(id: number): void {
    this.driveService.getDriveById(id).subscribe((drive: VaccinationDrive) => {
      this.driveForm.patchValue({
        driveName: drive.driveName,
        date: this.formatDateForInput (new Date(drive.date)),
        vaccineId: drive.vaccineId,
        availableDoses: drive.availableDoses,
        applicableClasses:drive.applicableClasses
      });

     
    });
  }

  
formatDateForInput(date: Date): string {
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0'); // Months are 0-based
    const day = String(date.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
  }
  
  onSubmit(): void {
    if (this.driveForm.invalid) return;

    const formValue = this.driveForm.value;
    const payload = {
      ...formValue,
      applicableClasses: formValue.applicableClasses
    };
    if (this.driveId) {
      this.driveService.updateDrive(this.driveId, payload).subscribe(() => 

        this.router.navigate(['/drives'])
      );
    } else {
      this.driveService.createDrive(payload).subscribe({
        next: (response) => {
          console.log('Drive created successfully:', response);
          this.router.navigate(['/drives']);
        },
        error: (error) => console.error('Error creating drive:', error)
      });
    }
  }

  private futureDateValidator(minDays: number) {
    return (control: any) => {
      const inputDate = new Date(control.value);
      const minDate = new Date();
      minDate.setDate(minDate.getDate() + minDays);
      return inputDate >= minDate ? null : { dateTooSoon: true };
    };
  }
}
