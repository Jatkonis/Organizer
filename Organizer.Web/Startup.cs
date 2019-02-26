using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Organizer.Core.Services;

namespace Organizer.Web
{
    /*
     *  1- Structure of the application:
     *      - Organizer.Web -> web project, responsible for displaying events, has triggers to create/update/delete
     *          - EventViewModel -> view representation of Event
     *          - EventMapper -> Mapper to map Event <-> EventViewModel
     *          - All pages for viewing
     *      - Organizer.Core -> separate project, which contains all logic and infrastructure code
     *          - IEventDataStore -> Responsible for CRUD operations on events, but uses an injected repository to persist changes
     *          - IEventRepository -> Handles read/write operations to JSON (and later - to SQL)
     *          - Event -> your main domain model - the one that contains data
     *      - Organizer.Core.UnitTests
     *          - EventDataStoreTests -> tests to ensure the store does what its supposed to
     *          - JsonEventRepositoryTests -> tests to ensure json file is being read/written properly
     *      - Organizer.Web.UnitTests
     *          - EventMapperTests -> tests to ensure mapping is being done correctly.
     *
     *      - What we achieve with doing above
     *          - Single Responsibility Principle - each component does exactly what it says it does
     *          - Testability - smaller components are much easier to test
     *          - Open Closed principle - IEventDataStore component won't need to change when we introduce SQL repository
     *          - Consistent project naming
     *          - Separation of business logic from UI logic -> you can easily have a console app in this solution using IEventDataStore without having to duplicate anything
     */

    /*
     * 1- Finish fixing compile errors.
     * 2- Add/finish unit tests.
     * 3- Make sure everything still works :)))
     * 4- Fix ID bug.
     */

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: from Dependency Injection -> what's the difference between Singleton, Transient, Scoped?
            services.AddSingleton<IEventStore, EventStore>();
            services.AddSingleton<IEventDataRepository, JsonEventDataRepository>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
