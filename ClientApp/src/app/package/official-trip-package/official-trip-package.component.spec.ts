import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OfficialTripPackageComponent } from './official-trip-package.component';

describe('OfficialTripPackageComponent', () => {
  let component: OfficialTripPackageComponent;
  let fixture: ComponentFixture<OfficialTripPackageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OfficialTripPackageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OfficialTripPackageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
