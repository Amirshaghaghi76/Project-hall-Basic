import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeddingAdviceComponent } from './wedding-advice.component';

describe('WeddingAdviceComponent', () => {
  let component: WeddingAdviceComponent;
  let fixture: ComponentFixture<WeddingAdviceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WeddingAdviceComponent]
    });
    fixture = TestBed.createComponent(WeddingAdviceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
