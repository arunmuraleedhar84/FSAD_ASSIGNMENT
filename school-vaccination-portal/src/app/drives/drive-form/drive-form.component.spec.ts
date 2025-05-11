import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DriveFormComponent } from './drive-form.component';

describe('DriveFormComponent', () => {
  let component: DriveFormComponent;
  let fixture: ComponentFixture<DriveFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DriveFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DriveFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
