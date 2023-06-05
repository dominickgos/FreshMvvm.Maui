﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using FreshMvvm.Maui.Extensions;
using Microsoft.Maui.Controls;

namespace FreshMvvmApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

#if ANDROID
            builder.ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler<TabbedPage, CustomTabbedPageHandler>();
            });
#endif

            builder.Services.Add(ServiceDescriptor.Singleton<IDatabaseService, DatabaseService>());

            builder.Services.Add(ServiceDescriptor.Transient<ContactListPage, ContactListPage>());
            builder.Services.Add(ServiceDescriptor.Transient<ContactPage, ContactPage>());
            builder.Services.Add(ServiceDescriptor.Transient<MainMenuPage, MainMenuPage>());
            builder.Services.Add(ServiceDescriptor.Transient<ModalPage, ModalPage>());
            builder.Services.Add(ServiceDescriptor.Transient<QuoteListPage, QuoteListPage>());
            builder.Services.Add(ServiceDescriptor.Transient<QuotePage, QuotePage>());
            builder.Services.Add(ServiceDescriptor.Transient<Test1Page, Test1Page>());

            builder.Services.Add(ServiceDescriptor.Transient<ContactListPageModel, ContactListPageModel>());
            builder.Services.Add(ServiceDescriptor.Transient<ContactPageModel, ContactPageModel>());
            builder.Services.Add(ServiceDescriptor.Transient<MainMenuPageModel, MainMenuPageModel>());
            builder.Services.Add(ServiceDescriptor.Transient<ModalPageModel, ModalPageModel>());
            builder.Services.Add(ServiceDescriptor.Transient<QuoteListPageModel, QuoteListPageModel>());
            builder.Services.Add(ServiceDescriptor.Transient<QuotePageModel, QuotePageModel>());
            builder.Services.Add(ServiceDescriptor.Transient<Test1PageModel, Test1PageModel>());



            MauiApp mauiApp = builder.Build();

            mauiApp.UseFreshMvvm();

            return mauiApp;
        }
    }
}