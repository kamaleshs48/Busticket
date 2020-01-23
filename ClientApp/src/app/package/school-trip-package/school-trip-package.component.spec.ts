import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SchoolTripPackageComponent } from './school-trip-package.component';

describe('SchoolTripPackageComponent', () => {
  let component: SchoolTripPackageComponent;
  let fixture: ComponentFixture<SchoolTripPackageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SchoolTripPackageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SchoolTripPackageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
