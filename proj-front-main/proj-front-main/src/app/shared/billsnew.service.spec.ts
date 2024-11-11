import { TestBed } from '@angular/core/testing';

import { BillsnewService } from './billsnew.service';

describe('BillsnewService', () => {
  let service: BillsnewService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BillsnewService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
