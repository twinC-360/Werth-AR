using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class LocalizationManager
{
    public static Locale ActiveLocale
    {
        get
        {
            return LocalizationSettings.SelectedLocale;
        }
    }

    private static void Awake()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale(Application.systemLanguage);
    }
}
