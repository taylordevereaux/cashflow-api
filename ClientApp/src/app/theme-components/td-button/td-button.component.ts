import { Component, OnInit, Input, HostBinding } from '@angular/core';
import { Colors } from '../colors.enum';
import { Sizes } from '../sizes.enum';

@Component({
  selector: '[td-button]',
  templateUrl: './td-button.component.html',
  styleUrls: ['./td-button.component.scss']
})
export class TdButtonComponent implements OnInit {
  @Input() class = '';
  @Input() color: Colors = Colors.none;
  @Input() size: Sizes = Sizes.normal;
  @Input() pill: boolean = false;
  @Input() outline: boolean = false;

  constructor() {}

  @HostBinding('class')
  get hostClasses(): string {
    return [
      'btn ',
      this.colorClass,
      this.sizeClass,
      this.pillClass,
      this.class
    ].join(' ');
  }

  ngOnInit() {
    this.outline = this.outline || this.outline !== undefined;
    this.pill = this.pill || this.pill !== undefined;
  }

  private get colorClass() {
    const prefix = this.outline ? 'btn-outline-' : 'btn-';
    return this.color !== Colors.none ? `${prefix}${this.color}` : '';
  }
  private get sizeClass() {
    return this.size !== Sizes.normal ? `btn-${this.size}` : '';
  }
  private get pillClass() {
    return this.pill ? 'btn-pill' : '';
  }
}
