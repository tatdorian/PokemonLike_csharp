   M S B A M L   `   `   `  ����  PokemonLikeCsharp,    &PokemonLikeCsharp.PokemonDetailsWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Détails du Pokémon��5   	   ���#F0F4F8 � WindowState$ 	Maximized=�5   	    � WindowStyle$
 None=�5   	    � 	Resources 5	         ButtonStyle �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   ShadowDepth	   Color��%  &	        �� 5
   
   " ��6$   .�5      ��  � �� �#2196F36+   �� 5       � ��
 �����6+   �� 5       � ��$
 12,6q�6(   �� 5       � ��$ 16(�6)   �� 5       � ��$
 Bold"�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� �#1976D26,   �� 5       � ��$ 2q�60   �� 5       � ��$ 10q�6'   �� 5       � ��$ Center=�64   �� 5       �@J�Effect 5        5      $ 5Q�6'   $ 2Q�66   $
	 Gray��6F   5      5      5      .��5      � $��30q�6   
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   �� 5       $��* �6   �� 5!      $
��Auto �6   .+�5$   
   �� $��Détails du Pokémon��6   $��32(�6.   $
��Bold"�6<   ���#333$��Center=�5%      $��10q�61   �� 5'   
   $��1��6   $��Center=�6"   $��Center=�6?   $	��400��6Z   .+�5(      �� $��Nom :��6   $
��0,10q�6%   $��16(�63   $��SemiBold"�6A   �� 5)      -   5         ��Name$ txtName��5)       �� Padding$ 8q�6)   $	��0,5q�65   �� 5+      $��Santé :��6   $
��0,10q�6'   $��16(�65   $��SemiBold"�6C   �� 5,      -   5        $ 	txtHealth��5,      $ 8q�6+   $	��0,5q�67   �� 5.      $
��0,20q�6   ���#B0BEC5$��1q�69   $	��150��6M   $	��150��6Y   $��Center=�6f   ._�5/      �� -   5         ��Name$ 
imgPokemon��5/      $��Uniform=�6,   50      �� 52      $��Sorts :��6   $��20,10q�6'   $��16(�66   $��SemiBold"�6D   �� 53      -   5         ��Name$ SpellsStackPanel��53      $��10q�63   54      �� 56   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��20q�6X   .+�57      �� -   5        $��Modifier��57      #��[  6E   �� 58      -   5        $��Ajouter des Sorts��58      #��[  6L   �� 59      -   5         ��Name$ btnStartBattle��59      $��Lancer un combat��6-   #��[  6H   $	��200��6�   $��38��6�   $��10q�6�   �� 5:      -   5        $��Fermer��5:      #��[  6:   ���#F443366_   5;      5<      5=      