   M S B A M L   `   `   `  ����F  BApp_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:App_ProjectApp_Project  5   	   #    App_Project.UpdateCustomOrder   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:App_Project     5   	     � Title$  UpdateCustomOrder��5   	   $	��550��6#   $	��800��60   .��5	      � 
����ح�$��	0,0,0,-59q�6"   .+�5   
   �� -   5        $
��Back��5      $��80��6    $��35��6+   
�������
���   �$
��Bold"�5   7   $��14(�6I   $��0q�5      $
��Left=�6%   $	��Top=�6@   $��10q�6X   �� 5   
   
������� �� CornerRadius$ 15��6$    �� Padding$ 20q�66   $	��600��6C   $	��416��6O   $��Center=�5      $��Center=�6,    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6#      	Direction$	 270Q�61      ShadowDepth$ 5Q�6A      Opacity$	 0.3Q�6Q   ._�5      �� .+�5      �� $��Update Custom Order��6   $��24(�67   $
��Bold"�6E   $��Center=�5      $��	0,10,0,20q�69   �� 5      $��Product Description��6   $��16(�67   $��SemiBold"�6E   $��10,0,0,0q�6[   �� 5      -   5         ��Name$ ProductDescriptionBox��5      $	��350��69   $��80��6E   $��10q�6Q   	 �� TextWrapping$
	 Wrap=�6]   
 �� AcceptsReturn
 . 6q   �� 5       $��Price��6   $��16(�6)   $��SemiBold"�67   $��10,0,0,0q�6M   �� 5!      -   5        $ PriceBox��5!      $	��250��6,   $��22��68   $��10q�6D   �� 5$      $��Quantity��6   $��16(�6,   $��SemiBold"�6:   $��10,0,0,0q�6P   �� 5%      -   5        $ QuantityBox��5%      $	��250��6/   $��22��6;   $��10q�6G   �� 5(      -   5        $��Update Order��5(      $	��170��60   $��40��6<   ���#FFC107
���   �$
��Bold"�5)   A   $��15(�6S   $��0q�5*      $��Center=�6-   $��10q�6J   5+      5,      5-      5.      