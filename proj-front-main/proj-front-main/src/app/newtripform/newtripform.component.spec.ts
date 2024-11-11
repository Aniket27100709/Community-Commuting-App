import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewtripformComponent } from './newtripform.component';

describe('NewtripformComponent', () => {
  let component: NewtripformComponent;
  let fixture: ComponentFixture<NewtripformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewtripformComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewtripformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
