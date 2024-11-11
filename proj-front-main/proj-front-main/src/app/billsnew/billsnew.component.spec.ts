import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BillsnewComponent } from './billsnew.component';

describe('BillsnewComponent', () => {
  let component: BillsnewComponent;
  let fixture: ComponentFixture<BillsnewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BillsnewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BillsnewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
