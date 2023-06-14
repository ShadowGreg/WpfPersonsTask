using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfSimpleAppToolKit.Model; 

public class ApplicationViewModel: ObservableObject {
    [ObservableProperty]
    private  Phone _selectedPhoneB;
    
    public static ObservableCollection<Phone> Phones { get; set; }
    
    public ApplicationViewModel() {
        Phones = new ObservableCollection<Phone>
        {
            new Phone("Nikita", "890762345812345687"),
            new Phone("Vika","890324523434545687"),
            new Phone( "Misha", "890765674567456787"),
            new Phone("Nina","890762348907890687"),
            new Phone("Marina","890762345235245687"),
            new Phone("Lena","890123890345345687")
        };
        _selectedPhoneB = Phones[0];
    }
}