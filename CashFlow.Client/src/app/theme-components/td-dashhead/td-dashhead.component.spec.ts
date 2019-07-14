/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TdDashheadComponent } from './td-dashhead.component';

describe('TdDashheadComponent', () => {
  let component: TdDashheadComponent;
  let fixture: ComponentFixture<TdDashheadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TdDashheadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TdDashheadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
