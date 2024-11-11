import { TestBed } from '@angular/core/testing';

import { RideprovidesService } from './rideprovides.service';

describe('RideprovidesService', () => {
  let service: RideprovidesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RideprovidesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
