   M S B A M L   `   `   `  ����G  CPaintShopWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PaintShopWPFPaintShopWPF  5          PaintShopWPF.ShopPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:PaintShopWPF     5      -   5          >�Name$
  Boop��5      $	��750��5   7   $	��610��6C   .��5	      � -   5         �Name$ shopHost��5	      ���	#FFDFFBF9 J� IsManipulationEnabled . }�. $
��Left=�6e   $	��Top=�6�    J� SnapsToDevicePixels .  � RowDefinitions 5
   
   �� 5      $	��610 �6    � ColumnDefinitions 5   
   �� 5      $	��750 �6   .+�5   
   �� ���	#FF2C7873$
��Left=�6%   $��45��6@   $��	10,10,0,0q�6L    �� RadiusY$ 20��6_    �� RadiusX$ 20��6l   $��0��6y   $	��Top=�6�   $	��730��6�   �� 5   
   $
��Left=�6   $	��555��62   $��0,55,0,0q�6?   $	��Top=�6Q   $	��750��6i    �� PanningMode$ VerticalOnly=�6u   .��5      � -   5        	 �Name$	 elementsHost��5      $��0q�6.   5      � 5   
   -   5        $ 	paintType��5      $
��Left=�6"   $��45��6=   $��	40,10,0,0q�6I   $	��Top=�6\   $	��160��6t   ���	#FF2C7873.+�5      �� -   5        
 ��Name$
 	textBlock��5      $
��Left=�6+   $��	30,10,0,0q�6F   $
��Wrap=�6Y   $��Тип краски��6m   $	��Top=�6   $��25��6�   $��20(�6�   $1��+/PaintShopWPF;component/Fonts/#Ubuntu Light)�6�   ���	#FFDFFBF96�   5      � 5   
   -   5        $ 	brandType��5      $
��Left=�6"   $��45��6=   $��
200,10,0,0q�6I   $	��Top=�6]   $	��160��6u   ���	#FF2C7873.+�5      �� -   5        $
 
textBlock1��5      $
��Left=�6,   $��7,10,0,0q�6G   $
��Wrap=�6Y   $ ��Производитель��6m   $	��Top=�6�   $��25��6�   $��20(�6�   $1��+/PaintShopWPF;component/Fonts/#Ubuntu Light)�6�   ���	#FFDFFBF96�   5      � 5   
   -   5        $	 brandOptions��5      $
��Left=�6*   $	��545��6E   $��
200,55,0,0q�6R   $	��Top=�6f   $	��160��6~   $y�Hidden=�6�   � 5   
   -	   5        $	 paintOptions��5      $
��Left=�6*   $	��545��6E   $��	40,55,0,0q�6R   $	��Top=�6e   $	��160��6}   $y�Hidden=�6�   5      5      