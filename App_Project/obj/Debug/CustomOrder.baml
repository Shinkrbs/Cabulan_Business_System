   M S B A M L   `   `   `  ����F  BApp_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:App_ProjectApp_Project  5   	       App_Project.CustomOrder   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:App_Project     5   	     � Title$  CustomOrder��5   	   $	��750��6   $	��900��6*   
����ح�.��5
      � .+�5   
   �� -   5        $
��Back��5      $��80��6    $��35��6+   
�������
���   �$
��Bold"�5   7   $��17(�6I   $��0q�5      $
��Left=�6%   $	��Top=�6@   $��10q�6X   �� 5   
   
������� �� CornerRadius$ 15��6$    �� Padding$ 20q�66   $	��600��6C   $	��632��6O   $��Center=�5      $��Center=�6,    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6#      	Direction$	 270Q�61      ShadowDepth$ 5Q�6A      Opacity$	 0.3Q�6Q   ._�5      �� .+�5      �� $��Custom Order��6   $��24(�60   $
��Bold"�6>   $��Center=�5      $��	0,10,0,20q�69   �� 5      $��Select Customer��6   $��16(�63   $��SemiBold"�6A   $��10,0,0,0q�6W   �� 5      -   5         ��Name$ CustomerComboBox��5      $	��250��65   $��25��6A   $��10q�6M   �� 5!      $$��Input Custom Order Description��6   $��16(�6B   $��SemiBold"�6P   $��10,0,0,0q�6f   �� 5"      -   5        	 ��Name$	 CustomOrderBox��5"      $	��358��62   $	��114��6>   $��10q�6K   
 �� TextWrapping$

 Wrap=�6W    �� AcceptsReturn . 6k   �� 5%      $��Price��6   $��16(�6)   $��SemiBold"�67   $��10,0,0,0q�6M   �� 5&      -   5        $	 PriceBox��5&      $	��250��6,   $��22��68   $��10q�6D   6P   �� 5)      $��Quantity��6   $��16(�6,   $��SemiBold"�6:   $��10,0,0,0q�6P   �� 5*      -   5        $	 QuantityBox��5*      $	��250��6/   $��22��6;   $��10q�6G   6S   �� 5-      $��Assign Employee��6   $��16(�63   $��SemiBold"�6A   $��10,0,0,0q�6W   �� 5.      -   5        $ EmployeeComboBox��5.      $	��250��65   $��25��6A   $��10q�6M   �� 51      -   5        $��Confirm Custom Order��51      $	��200��68   $��40��6D   ���#28A745
�������$
��Bold"�52   A   $��15(�6S   $��0q�53      $��Center=�6-   $��10q�6J   �� 56      -   5         ��Name$ FeedbackTextBlock��56      $�� ��67   
��� � �$
��Bold"�6R   $��14(�57       �� TextAlignment$ Center=�6'   $��10q�6>   $y�	Collapsed=�6J   �� 5:      -	   5        $��View Custom Orders��5:      $	��200��66   $��35��6B   ���#007BFF
�������$
��Bold"�5;   =   $��14(�6O   $��0q�5<      $��Center=�6)   $��5q�6F   5>      5?      5@      5A      