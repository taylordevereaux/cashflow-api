/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TdDashheadToolbarDividerComponent } from './td-dashhead-toolbar-divider.component';

describe('TdDashheadToolbarDividerComponent', () => {
  let component: TdDashheadToolbarDividerComponent;
  let fixture: ComponentFixture<TdDashheadToolbarDividerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TdDashheadToolbarDividerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TdDashheadToolbarDividerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
