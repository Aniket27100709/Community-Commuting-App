import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RideprovideComponent } from './rideprovide.component';

describe('RideprovideComponent', () => {
  let component: RideprovideComponent;
  let fixture: ComponentFixture<RideprovideComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RideprovideComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RideprovideComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
