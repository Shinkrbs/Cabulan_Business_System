   M S B A M L   `   `   `  ����F  BApp_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:App_ProjectApp_Project  5   	       App_Project.OrdersPage   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:App_Project     5   	     � Title$  
OrdersPage��5   	   $	��750��6   $	��900��6*   
����ح�.��5
      � .+�5   
   �� -   5        $
��Back��5      $��80��6    $��35��6+   
�������
���   �$
��Bold"�5   7   $��17(�6I   $��0q�5      $
��Left=�6%   $	��Top=�6@   $��10q�6X   �� 5   
   
������� �� CornerRadius$ 15��6$    �� Padding$ 20q�66   $	��600��6C   $	��684��6O   $��Center=�5      $��Center=�6,    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6#      	Direction$	 270Q�61      ShadowDepth$ 5Q�6A      Opacity$	 0.3Q�6Q   ._�5      �� .+�5      �� $��Order Management��6   $��24(�64   $
��Bold"�6B   $��Center=�5      $��	0,10,0,20q�69   �� 5      $��Select Customer��6   $��16(�63   $��SemiBold"�6A   $��10,0,0,0q�6W   �� 5      -   5         ��Name$ CustomerComboBox��5      $	��250��65   $��25��6A   $��10q�6M   �� 5!      $��Select Product��6   $��16(�62   $��SemiBold"�6@   $��10,0,0,0q�6V   �� 5"      -   5        $ ProductComboBox��5"      $	��250��64   $��25��6@   $��10q�6L   5#      �� 5&      $��Quantity��6   $��16(�6,   $��SemiBold"�6:   $��10,0,0,0q�6P   �� 5'      -   5        	 ��Name$	 QuantityBox��5'      $	��250��6/   $��22��6;   $��10q�6G   �� 5*      $��Assign Employee��6   $��16(�63   $��SemiBold"�6A   $��10,0,0,0q�6W   �� 5+      -   5        $ EmployeeComboBox��5+      $	��250��65   $��25��6A   $��10q�6M   �� 5.      $��Total Amount��6   $��16(�60   $��SemiBold"�6>   $��10,0,0,0q�6T   �� 5/      -   5        $	 TotalAmountBox��5/      $	��250��62   $��22��6>   $��10q�6J   
 �� 
IsReadOnly
 . 6V   �� 52       �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�53      �� -   5        $��Place Order��53      $	��120��63   $��40��6?   ���#0078D7
�������$
��Bold"�54   E   $��15(�6W   $��0q�55      $��5q�61   �� 57      -   5        $��Custom Order��57      $	��120��64   $��40��6@   ���#28A745
�������$
��Bold"�58   E   $��15(�6W   $��0q�59      $��5q�61   5:      &   System.Windows.Controls.DataGrid  5=      -	   5          Name$ OrderDataGrid��5=      $	��533��62   $	��187��6>   $��10q�6K      AutoGenerateColumns .     HeadersVisibility$ Column=�5>   7      Columns 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ Customer ID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *
CustomerId+6a     5A      $ Total Order��6-   $ * 6b    6B   �� *TotalAmount+6b   5C      5E      5F      5G      5H      