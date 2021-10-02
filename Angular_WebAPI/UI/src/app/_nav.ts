import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Order',
    url: '/order',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  {
    title: true,
    name: 'OTHER'
  },
  {
    name: 'Invoice',
    url: '/other/invoice',
    icon: 'icon-drop'
  },
  {
    name: 'Transaction',
    url: '/other/transaction',
    icon: 'icon-pencil'
  },
  
];
