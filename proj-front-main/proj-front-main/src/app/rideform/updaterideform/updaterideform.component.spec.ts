import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdaterideformComponent } from './updaterideform.component';

describe('UpdaterideformComponent', () => {
  let component: UpdaterideformComponent;
  let fixture: ComponentFixture<UpdaterideformComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdaterideformComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdaterideformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
